
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
export default function Admin()
{
    
  return(
    <div>
        <h1>This is Admin Portal !</h1>
        <Link to={`/servicess`} className="btn btn-outline-primary mx-2">Services</Link>
        <Link to={`/clientss`} className="btn btn-outline-primary mx-2">Clients</Link>
        <Link to={`/allservices`} className="btn btn-outline-primary mx-2">All Services</Link>

    </div>
  )
}