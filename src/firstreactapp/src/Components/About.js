import React from "react";

export default function About() {
  const containerStyle = {
    width: "300px",
    margin: "auto",
    padding: "20px",
    border: "1px solid #ccc",
    borderRadius: "8px",
    boxShadow: "0px 2px 4px rgba(0, 0, 0, 0.1)",
    textAlign: "center"
  };

  const ownerNameStyle = {
    fontSize: "24px",
    fontWeight: "bold",
    marginBottom: "10px"
  };

  const emailStyle = {
    color: "#007bff",
    textDecoration: "none",
    display: "block",
    marginBottom: "10px"
  };

  const contactStyle = {
    fontSize: "16px",
    fontWeight: "bold"
  };

  return (
    <div style={containerStyle}>
      <h5>Owner Name:</h5>
      <h6 style={ownerNameStyle}>Ajay Narkhede</h6>
      <a href="mailto:ajaynarkhede888@gmail.com" style={emailStyle}>
        ajaynarkhede888@gmail.com
      </a>
      <p style={contactStyle}>Contact No: 9834299172</p>
    </div>
  );
}
