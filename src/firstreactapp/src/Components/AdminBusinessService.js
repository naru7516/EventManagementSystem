import React, { useEffect, useState } from "react";
import axios from "axios";
import { Link, useNavigate, useParams } from "react-router-dom";
export default function AdminBusinessServiceComp() {
    const [bservice,setBservice]=useState([])
    const {id}=useParams()

    useEffect(()=>{
        loadBservices();
    },[]);    

  useEffect(() => {
    fetch("https://localhost:7176/api/BuisnessServices")
      .then(resp => resp.json())
      .then(bservice => setBservice(bservice));
  }, []);

  const loadBservices=async ()=>{
    const result=await axios.get("https://localhost:7176/api/BuisnessServices")
    setBservice(result.data);
}

const deleteBservice=async(id)=>{
    await axios.delete(`https://localhost:7176/api/BuisnessServices/${id}`)

            loadBservices()
}


  return (
    <div style={{ textAlign: "center" }}>
      <h1>bservice List:</h1>

      <table style={{ margin: "0 auto", borderCollapse: "collapse", border: "1px solid #ccc", width: "70%" }}>
        <thead>
          <tr>
            <th style={{ border: "1px solid #ccc" }} scope="col">Id.</th>
            <th style={{ border: "1px solid #ccc" }} scope="col"> Name</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Description</th>
            <th style={{ border: "1px solid #ccc" }} scope="col">Price</th>
         

          </tr>
        </thead>
        <tbody>
          {bservice.map((v, index) => (
            <tr key={v.id}>
              <td style={{ border: "1px solid #ccc" }}>{v.id}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.name}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.description}</td>
              <td style={{ border: "1px solid #ccc" }}>{v.price}</td>

              <td>
              <button className="btn btn-danger mx-2"
                                onClick={()=>deleteBservice(v.id)}>Delete</button>              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
