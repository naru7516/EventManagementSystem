import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import axios from "axios";

export default function BServiceComp() {
  const [venue, setVenue] = useState([]);

  const { id } = useParams();
  useEffect(() => {
    loadVenue();
  }, []);


  const loadVenue = async () => {
    try {
// alert("IN try")
        const response = await axios.get(`https://localhost:7176/getbservicebyId?id=${id}`)
        setVenue(response.data);
        console.log(venue)
        
    } catch (error) {
// alert("in catch")
      console.error("error loading data", error);
 

    }
  };

  return (
    <div>
      <div style={{ textAlign: "center" }}>
        <h1> Services</h1>


        <table style={{ margin: "0 auto", borderCollapse: "collapse", border: "1px solid #ccc", width: "70%" }}>
          <thead>
            <tr>
              <th style={{ border: "1px solid #ccc" }} scope="col">Service Name</th>
              <th style={{ border: "1px solid #ccc" }} scope="col">Service Description</th>
              <th style={{ border: "1px solid #ccc" }} scope="col">Price</th>
              <th style={{ border: "1px solid #ccc" }} scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            
            {venue.map((v, index) => (
              <tr key={v.id}>
                <td style={{ border: "1px solid #ccc" }}>{v.name}</td>
                <td style={{ border: "1px solid #ccc" }}>{v.description}</td>
                <td style={{ border: "1px solid #ccc" }}>{v.price}</td>
                <td>
                  <Link to={`/buy/${v.id}`} className="btn btn-outline-primary mx-2">Add</Link>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      
    </div>
    
  );
}
