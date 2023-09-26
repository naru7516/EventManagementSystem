import React from "react";
import { Link } from "react-router-dom";

export default function Payments() {
    const currentDate = new Date();
    const formattedDate = currentDate.toLocaleDateString();
    const formattedTime = currentDate.toLocaleTimeString();

    return (
        <div className="container">
            <table>
                <tr>
                    <h1>Payment Successful</h1><br />
                </tr>
                <tr>
                    <td>Purchase Date: {formattedDate}</td>
                </tr>
                <tr>
                    <td>Purchase Time: {formattedTime}</td>
                </tr>
                <tr>
                    <td>
                        <Link to={"/clientpage"} className="btn btn-danger mx-2">
                            Go back to Home
                        </Link>
                    </td>
                    <td>
                        <Link to={"/"} className="btn btn-danger mx-2">
                            LOGOUT
                        </Link>
                    </td>
                </tr>
            </table>
        </div>
    );
}