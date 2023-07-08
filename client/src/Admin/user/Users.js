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
  {
    field: "",
    headerName: "Edit",
    type: "number",
    width: 90,
  },
];
export default function DataTable() {
  const [rows, setRows] = useState([]);
  useEffect(() => {
    axios
      .get("https://localhost:44359/api/users", {
        headers: {
          Authorization: `${sessionStorage.getItem("token")}`,
        },
      })
      .then((rs) => {
        let data = rs["data"];
        console.log(data);
        setRows(data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);
  return (
    <div>
 <div class="card" style="padding:2%">
    <div class="row">
        <div class="col">
            <nav aria-label="breadcrumb" class="bg-light rounded-3 p-3 mb-4">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="/dashboard">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Users</li>
                </ol>
            </nav>
        </div>
    </div>
    </div>
    <form class="d-block" action="/users/search">
        <input class="form-control me-2" name="search" type="search" placeholder="Search by name " aria-label="Search"><br />  
        <button class="btn btn-info btn-outline-success" type="submit">Search</button>
    </form>
    <br />
    <p>
        <a class="btn btn-primary" href="/users/create"> Add User </a>
    </p>
    <table class="table ">
        <tr>
            <th>
                Name
            </th>
            <th>
                Phone
            </th>
            <th>
                Email
            </th>
            <th>
                Usertype
            </th>
            <th>
                Account Status
            </th>
            <th>Action</th>
        </tr>

       


        

    </table>
</div>


    </div>
  );
}
