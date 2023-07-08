import React, { useEffect, useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import axios from "axios";
import Nav from "../../common/Nav";
const columns = [
  { field: "id", headerName: "ID", width: 70 },
  { field: "name", headerName: "Name", width: 130 },
  { field: "email", headerName: "Email", width: 130 },
  {
    field: "phone",
    headerName: "Phone",
    type: "number",
    width: 90,
  },
];
export default function DataTable() {
  const [rows, setRows] = useState([]);
  useEffect(() => {
    axios
      .get("https://localhost:44359/api/employees", {
        headers: {
          Authorization: `${sessionStorage.getItem("token")}`,
        },
      })
      .then((rs) => {
        let data = rs["data"];
        setRows(data);
      })
      .catch((error) => {
        console.error(error);
      });
  });
  return (
    <div style={{ height: 800, width: "100%" }}>
      <Nav></Nav>
      <DataGrid
        rows={rows}
        columns={columns}
        pageSize={10}
        rowsPerPageOptions={[10]}
        checkboxSelection
      />
    </div>
  );
}
