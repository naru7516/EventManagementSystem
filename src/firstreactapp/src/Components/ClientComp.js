import React from "react";
import { Link } from "react-router-dom";

export default function ClientComp() {
  const buttonContainerStyle = {
    display: "flex",
    justifyContent: "space-between",
    marginTop: "20px"
  };

  const customButtonStyle = {
    display: "inline-block",
    padding: "10px 20px",
    border: "none",
    backgroundColor: "#007bff",
    color: "#fff",
    fontSize: "16px",
    textDecoration: "none",
    cursor: "pointer",
    transition: "background-color 0.3s ease-in-out"
  };

  const customButtonHoverStyle = {
    backgroundColor: "#0056b3"
  };

  return (
    <div>
      <h4>We are here to provide services and the best to clients</h4>

      <div style={buttonContainerStyle}>
        <Link
          to={`/decoration`}
          style={customButtonStyle}
          onMouseOver={e => (e.target.style.backgroundColor = "#0056b3")}
          onMouseOut={e => (e.target.style.backgroundColor = "#007bff")}
        >
          Decoration
        </Link>
        <Link
          to={`/catering`}
          style={customButtonStyle}
          onMouseOver={e => (e.target.style.backgroundColor = "#0056b3")}
          onMouseOut={e => (e.target.style.backgroundColor = "#007bff")}
        >
          Catering
        </Link>
        <Link
          to={`/venue`}
          style={customButtonStyle}
          onMouseOver={e => (e.target.style.backgroundColor = "#0056b3")}
          onMouseOut={e => (e.target.style.backgroundColor = "#007bff")}
        >
          Venue
        </Link>
      </div>
    </div>
  );
}
