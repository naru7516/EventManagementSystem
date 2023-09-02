import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";
export default function AdminClientsComp() {
    const [client,setClient]=useState([])
    const {id}=useParams()

    useEffect(()=>{
        loadClients();
    },[]);    

  useEffect(() => {
    fetch("https://localhost:7176/api/Client/api/Client/getAll")
      .then(resp => resp.json())
      .then(client => setClient(client));
  }, []);

  const loadClients=async ()=>{
    const result=await axios.get("https://localhost:7176/api/Client/api/Client/getAll")
    setClient(result.data);
}

const deleteClient=async(id)=>{
    await axios.delete(`https://localhost:7176/api/Client/api/Client/delete/${id}`)

            loadClients()
}


  return (
    <div style={{ textAlign: "center" }}>
      <h1>Client List:</h1>

      <table style={{ margin: "0 auto", borderCollapse: "collapse", border: "1px solid #ccc", width: "70%" }}>
        <thead>
          <tr>
            <th style={{ border: "1px solid #ccc" }} scope="col">Id.</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Client Name</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Client Email</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Contact Number</th>
         

          </tr>
        </thead>
        <tbody>
          {client.map((v, index) => (
            <tr key={v.id}>
              <td style={{ border: "1px solid #ccc" }}>{v.id}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.name}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.email}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.contactNumber}</td>

              <td>
              <button className="btn btn-danger mx-2"
                                onClick={()=>deleteClient(v.id)}>Delete</button>              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
