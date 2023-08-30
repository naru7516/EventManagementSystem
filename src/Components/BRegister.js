import { useEffect, useReducer, useState } from "react";
import { useNavigate } from "react-router-dom";
export default function BusinessRegister()
{   
    const navigate=useNavigate();
    const[msg,setMsg]=useState();
    const init={
        id:1,
        username: "",
        password: "",
        name: "",
        email: "",
        contactNumber: "",
        registrationNumber:"",
        houseNumber: "",
        area: "",
        city: "",
        pincode: "",
        state: "",
        userTypeId: 1
    }
    const reducer=(state,action)=>{
        switch(action.type)
        {
            case 'update':
                return{...state, [action.fld]:action.val}
            case 'reset':
                return init;
        }
    }

    const[info,dispatch]=useReducer(reducer,init);
   
    const sendData = (e)=>{
        e.preventDefault();
        const reqOptions = {
            method:'POST',
            headers:{'content-type':'application/json'},
            body: JSON.stringify(info)
        }
        console.log(reqOptions);
        fetch("https://localhost:7176/saveBusinessRegister",reqOptions)
        .then(resp => {
            if(resp!=null)
            {
            console.log(resp);
            }
            
         }) }
    return (
        <div>
            Enter details for Business:

            <h4>Enter Your Details :</h4>
            <form>
            <div className="mb-3">
                    <label htmlFor="username" className="form-label">Enter Username</label>
                    <input type="text" className="form-control" id="username" name="username"  value={info.username}
                    onChange={(e)=>{dispatch({type:'update',fld:'username', val: e.target.value})}}/>     
                   <div id="emailHelp" className="form-text">We'll never share your info with anyone else. </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="password" className="form-label">Enter Password</label>
                    <input type="password" className="form-control" id="password" name="password" value={info.password}
                     onChange={(e)=>{dispatch({type:'update',fld:'password', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="name" className="form-label">Enter Name</label>
                    <input type="text" className="form-control" id="name" name="name" value={info.name}
                     onChange={(e)=>{dispatch({type:'update',fld:'name', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="email" className="form-label">Enter Email</label>
                    <input type="email" placeholder="abc@gmail.com" className="form-control" id="email" name="email" value={info.email}
                     onChange={(e)=>{dispatch({type:'update',fld:'email', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>

                <div className="mb-3">
                    <label htmlFor="contactNumber" className="form-label">Enter Contact Number</label>
                    <input type="text" className="form-control" id="contactNumber" name="contactNumber" value={info.contactNumber}
                     onChange={(e)=>{dispatch({type:'update',fld:'contactNumber', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="registrationNumber" className="form-label">Enter Registration Number</label>
                    <input type="text" className="form-control" id="registrationNumber" name="registrationNumber" value={info.registrationNumber}
                     onChange={(e)=>{dispatch({type:'update',fld:'registrationNumber', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="houseNumber" className="form-label">Enter HouseNumber</label>
                    <input type="text" className="form-control" id="houseNumber" name="houseNumber" value={info.houseNumber}
                     onChange={(e)=>{dispatch({type:'update',fld:'houseNumber', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="area" className="form-label">Enter Area</label>
                    <input type="text" className="form-control" id="area" name="area" value={info.area}
                     onChange={(e)=>{dispatch({type:'update',fld:'area', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="city" className="form-label">Enter City</label>
                    <input type="text" className="form-control" id="city" name="city" value={info.city}
                     onChange={(e)=>{dispatch({type:'update',fld:'city', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="pincode" className="form-label">Enter Pincode</label>
                    <input type="text" className="form-control" id="pincode" name="pincode" value={info.pincode}
                     onChange={(e)=>{dispatch({type:'update',fld:'pincode', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                </div>
                <div className="mb-3">
                    <label htmlFor="state" className="form-label">Enter State</label>
                    <input type="text" className="form-control" id="state" name="state" value={info.state}
                     onChange={(e)=>{dispatch({type:'update',fld:'state', val: e.target.value})}}/>
                    <div id="emailHelp" className="form-text"> .... </div>
                    {/* <p>{JSON.stringify(info)}</p> */}
                </div>
                <button type="submit" className="btn btn-primary mb-3" onClick={(e)=>{sendData(e)}}>register</button> 
                                        
                <button type="reset" className="btn btn-primary mb-3 " onClick={()=>{dispatch({type:'reset'})}}>Clear</button> 
                                        
            </form>

        </div>
    )
}