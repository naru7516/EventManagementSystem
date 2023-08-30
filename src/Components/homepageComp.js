
import { useEffect, useState } from 'react';
import '../App.css';
import { Collapse } from 'bootstrap';
function Home(){
    const[allservice,setService]=useState([])
    useEffect(()=>{
        fetch("https://localhost:7176/api/Categories")
        .then(resp=>resp.json())
        .then(service=>setService(service))
    },[]);
    console.log(JSON.stringify(allservice));
    return(
        <div>
        <h1>Welcome to EventManagmentSystem</h1>
        <h4>We are here to provide services and best to clients</h4>

      
        </div>
    );
}
export default Home;