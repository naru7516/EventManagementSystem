import { useEffect, useReducer, useState } from "react";
import { useNavigate } from "react-router-dom";

export default function SuccessfulReg()
{
    const navigate=useNavigate();


    const sendData = (e)=>{
        e.preventDefault();
        const reqOptions = {
            method:'POST',
            headers:{'content-type':'application/json'},
            body: JSON.stringify()
        }

        .then(resp => {
            if(resp==null)
            {
               navigate("/login");
            }
            
         }) }
    return(
        <div>
            <form>
        <h2 style={{color:"red"}}>Registration is Successfull !!</h2>
        <h5>Now You can login</h5>
        <br></br>

        </form>
        </div>
    )
}