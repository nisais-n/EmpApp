import React, { Component } from "react";

import { Button, ButtonGroup, ButtonToolbar, Table } from "react-bootstrap";

import { AddDepartment } from "./Components/AddDepartment";
import { EditDepartment } from "./Components/EditDepartment";

require("dotenv").config();
export const BASE_URL = process.env.REACT_APP_API;

export class Department extends Component {
  constructor(props) {
    super(props);
    this.state = {
      departments: [],
      addModalShow: false,
      editModalShow: false,
    };
  }

  refreshList = () => {
    fetch(BASE_URL + "Department/getDepartmentDetail")
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        this.setState({ departments: data });
      });
  };

  componentDidMount() {
    this.refreshList();
  }

  // componentDidUpdate() {
  //   this.refreshList();
  // }

  deleteDep(depid) {
    if (window.confirm("Are you sure?")) {
      fetch(BASE_URL + "Department/deleteDepartmentDetail=" + depid, {
        method: "DELETE",
        header: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
      });
    }
  }
  render() {
    const { departments, depid, depname } = this.state;
    let addModalClose = () => this.setState({ addModalShow: false });
    let editModalClose = () => this.setState({ editModalShow: false });
    return (
      <div>
        <Table className="mt-4" striped bordered hover size="sm">
          <thead>
            <tr>
              <th>DepartmentId</th>
              <th>DepartmentName</th>
              <th>Options</th>
            </tr>
          </thead>
          <tbody>
            {departments.map((dep, Index) => (
              <tr key={Index}>
                <td>{dep.DepartmentId}</td>
                <td>{dep.DepartmentName}</td>
                <td>
                  <ButtonToolbar>
                    <ButtonGroup></ButtonGroup>
                    <Button
                      className="me-2"
                      variant="info"
                      onClick={() =>
                        this.setState({
                          editModalShow: true,
                          depid: dep.DepartmentId,
                          depname: dep.DepartmentName,
                        })
                      }
                    >
                      Edit
                    </Button>
                    <Button
                      className="me-2"
                      variant="danger"
                      onClick={() => this.deleteDep(dep.DepartmentId)}
                    >
                      Delete
                    </Button>

                    <EditDepartment
                      show={this.state.editModalShow}
                      onHide={editModalClose}
                      depid={depid}
                      depname={depname}
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
            Add Department
          </Button>{" "}
          <AddDepartment
            show={this.state.addModalShow}
            onHide={addModalClose}
          />
        </ButtonToolbar>
      </div>
    );
  }
}
