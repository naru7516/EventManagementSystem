import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";
export default function AdminBusinesssComp() {
    const [business,setBusiness]=useState([])
    const {id}=useParams()

    useEffect(()=>{
        loadBusinesss();
    },[]);    

  useEffect(() => {
    fetch("https://localhost:7176/api/Businesses")
      .then(resp => resp.json())
      .then(business => setBusiness(business));
  }, []);

  const loadBusinesss=async ()=>{
    const result=await axios.get("https://localhost:7176/api/Businesses")
    setBusiness(result.data);
}

const deleteBusiness=async(id)=>{
    await axios.delete(`https://localhost:7176/api/Businesses/${id}`)

            loadBusinesss()
}


  return (
    <div style={{ textAlign: "center" }}>
      <h1>business List:</h1>

      <table style={{ margin: "0 auto", borderCollapse: "collapse", border: "1px solid #ccc", width: "70%" }}>
        <thead>
          <tr>
            <th style={{ border: "1px solid #ccc" }} scope="col">Id.</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">business Name</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">business Email</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Contact Number</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Registration Number</th>
         

          </tr>
        </thead>
        <tbody>
          {business.map((v, index) => (
            <tr key={v.id}>
              <td style={{ border: "1px solid #ccc" }}>{v.id}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.name}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.email}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.contactNumber}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.registrationNumber}</td>

              <td>
              <button className="btn btn-danger mx-2"
                                onClick={()=>deleteBusiness(v.id)}>Delete</button>              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
