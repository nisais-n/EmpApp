import React, { Component } from "react";

import { Button, ButtonToolbar, Table } from "react-bootstrap";

import { AddEmployee } from "./Components/AddEmployee";
import { EditEmployee } from "./Components/EditEmployee";

require("dotenv").config();
export const BASE_URL = process.env.REACT_APP_API;

export class Employee extends Component {
  constructor(props) {
    super(props);
    this.state = {
      employees: [],
      empAge: "test",
      addModalShow: false,
      editModalShow: false,
    };
  }

  refreshList() {
    fetch(BASE_URL + "employee/getEmployeeDetail")
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        this.setState({ employees: data });
      });
  }

  componentDidMount() {
    this.refreshList();
  }

  // componentDidUpdate() {
  //   this.refreshList();
  // }

  getAge(dob) {
    var Birth = new Date(dob);
    //calculate month difference from current date in time
    var month_diff = Date.now() - Birth.getTime();

    //convert the calculated difference in date format
    var age_dt = new Date(month_diff);

    //extract year from date
    var year = age_dt.getUTCFullYear();

    //now calculate the age
    var age = Math.abs(year - 1970);

    //display the calculated age
    //console.log("Age of the date entered: " + age + " years");
    return age + " Y";
  }

  deleteEmp(empid) {
    if (window.confirm("Are you sure?")) {
      fetch(BASE_URL + "employee/deleteEmployeeDetail=" + empid, {
        method: "DELETE",
        header: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
    }
    this.componentDidMount();
  }
  render() {
    const {
      employees,
      empid,
      empfname,
      emplname,
      empemail,
      empdepmt,
      empslry,
      empdob,
    } = this.state;
    let addModalClose = () => this.setState({ addModalShow: false });
    let editModalClose = () => this.setState({ editModalShow: false });
    return (
      <div>
        <Table className="mt-4" striped bordered hover size="sm">
          <thead>
            <tr>
              <th>EmployeeId</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Email</th>
              <th>DOB</th>
              <th>Age</th>
              <th>Department</th>
              <th>Salary</th>
              <th>Options</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((emp, Index) => (
              <tr key={Index}>
                <td>{emp.EmployeeId}</td>
                <td>{emp.FirstName}</td>
                <td>{emp.LastName}</td>
                <td>{emp.Email}</td>
                <td>{emp.DateOfBirth}</td>
                <td>{this.getAge(emp.DateOfBirth)}</td>
                <td>{emp.Department}</td>
                <td>{emp.Salary}</td>
                <td>
                  <ButtonToolbar>
                    <Button
                      className="me-2"
                      variant="info"
                      onClick={() =>
                        this.setState({
                          editModalShow: true,
                          empid: emp.EmployeeId,
                          empfname: emp.FirstName,
                          emplname: emp.LastName,
                          empemail: emp.Email,
                          empdepmt: emp.Department,
                          empslry: emp.Salary,
                          empdob: emp.DateOfBirth,
                        })
                      }
                    >
                      Edit
                    </Button>

                    <Button
                      className="mr-2"
                      variant="danger"
                      onClick={() => this.deleteEmp(emp.EmployeeId)}
                    >
                      Delete
                    </Button>

                    <EditEmployee
                      show={this.state.editModalShow}
                      onHide={editModalClose}
                      empid={empid}
                      empfname={empfname}
                      emplname={emplname}
                      empemail={empemail}
                      empdepmt={empdepmt}
                      empslry={empslry}
                      empdob={empdob}
                    />
                  </ButtonToolbar>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>

        <ButtonToolbar>
          <Button
            variant="primary"
            onClick={() => this.setState({ addModalShow: true })}
          >
            Add Employee
          </Button>

          <AddEmployee show={this.state.addModalShow} onHide={addModalClose} />
        </ButtonToolbar>
      </div>
    );
  }
}
