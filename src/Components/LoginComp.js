import { useEffect, useReducer, useState } from "react";
import { useNavigate } from "react-router-dom";

export default function LoginComp() {
  const navigate = useNavigate();
  const [msg, setMsg] = useState();
  const init = {
    Username: "",
    Password: ""
  };
  const reducer = (state, action) => {
    switch (action.type) {
      case "update":
        return { ...state, [action.fld]: action.val };
      case "reset":
        return init;
      default:
        return state;
    }
  };
  const [info, dispatch] = useReducer(reducer, init);
  const [trainer, viewTrainer] = useState([]);
  const sendData = (e) => {
    e.preventDefault();
    const reqOptions = {
      method: "POST",
      headers: { "content-type": "application/json" },
      body: JSON.stringify(info)
    };
    fetch("https://localhost:7176/chkLogin", reqOptions)
      .then((resp) => {
        if (resp.ok) return resp.text();
        else throw new Error("server Error");
      })
      .then((text) => (text.length ? JSON.parse(text) : {}))
      .then((obj) => {
        if (Object.keys(obj).length === 0) {
          setMsg("Wrong LOGINID/PASSWORD");
        } else {
          localStorage.setItem("loggedUser", JSON.stringify(obj));
          if (obj.userTypeId === 1) {
            navigate("/clientpage");
          } else if (obj.userTypeId === 2) {
            navigate("/business");
          }
        }
      })
      .catch((error) => alert("server error. Try after some time"));
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-lg-6">
          <div className="card">
            <div className="card-body">
              <h1 className="card-title text-center mb-4">Login Page</h1>
              <form>
                <div className="mb-3">
                  <label htmlFor="Username" className="form-label">
                    Enter Username
                  </label>
                  <input
                    type="text"
                    className="form-control"
                    id="Username"
                    name="Username"
                    value={info.Username}
                    onChange={(e) =>
                      dispatch({
                        type: "update",
                        fld: "Username",
                        val: e.target.value
                      })
                    }
                  />
                  <div id="emailHelp" className="form-text">
                    We'll never share your info with anyone else.
                  </div>
                </div>
                <div className="mb-3">
                  <label htmlFor="Password" className="form-label">
                    Enter Password
                  </label>
                  <input
                    type="password"
                    className="form-control"
                    id="Password"
                    name="Password"
                    value={info.Password}
                    onChange={(e) =>
                      dispatch({
                        type: "update",
                        fld: "Password",
                        val: e.target.value
                      })
                    }
                  />
                </div>
                <button
                  type="submit"
                  className="btn btn-primary mb-3"
                  onClick={(e) => {
                    sendData(e);
                  }}
                >
                  Login
                </button>
                <button
                  type="reset"
                  className="btn btn-secondary mb-3 ms-2"
                  onClick={() => {
                    dispatch({ type: "reset" });
                  }}
                >
                  Clear
                </button>
              </form>
              <p className="text-danger">{msg}</p>
              <button
                type="button"
                className="btn btn-danger me-2"
                onClick={() => {
                  navigate("/cregister");
                }}
              >
                Client Registration
              </button>
              <button
                type="button"
                className="btn btn-danger"
                onClick={() => {
                  navigate("/bregister");
                }}
              >
                Business Registration
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
