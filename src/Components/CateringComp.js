import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
export default function CateringComp() {
  const [catering, setCatering] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7176/api/Services/getservicebyId?id=1")
      .then(resp => resp.json())
      .then(catering => setCatering(catering));
  }, []);

  return (
    <div style={{ textAlign: "center" }}>
      <h1>Catering Services</h1>

      <table style={{ margin: "0 auto", borderCollapse: "collapse", border: "1px solid #ccc", width: "70%" }}>
        <thead>
          <tr>
            <th style={{ border: "1px solid #ccc" }} scope="col">No.</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Service Name</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Service Description</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Actions</th>

          </tr>
        </thead>
        <tbody>
          {catering.map((v, index) => (
            <tr key={v.id}>
              <td style={{ border: "1px solid #ccc" }}>{v.id}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.serviceName}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.serviceDescription}</td>
              <td>
            <Link to={`/bservice/${v.id}`} className="btn btn-outline-primary mx-2">Choose</Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
