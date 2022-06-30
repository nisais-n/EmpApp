import React, { Component } from "react";
import { Modal, Button, Row, Col, Form } from "react-bootstrap";

require("dotenv").config();
export const BASE_URL = process.env.REACT_APP_API;

export class AddEmployee extends Component {
  constructor(props) {
    super(props);
    this.state = {
      departments: [],
      salary: "",
    };
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    fetch(BASE_URL + "department/getAllDepartmentName")
      .then((response) => response.json())
      .then((data) => {
        this.setState({ departments: data });
      });
  }

  handleSubmit(event) {
    event.preventDefault();
    fetch(BASE_URL + "employee/addEmployeeDetail", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        FirstName: event.target.FirstName.value,
        LastName: event.target.LastName.value,
        Email: event.target.Email.value,
        DateOfBirth: event.target.DateOfBirth.value,
        Department: event.target.Department.value,
        Salary: event.target.Salary.value,
      }),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          alert(result);
        },
        (error) => {
          alert("Failed");
        }
      );
  }

  NumericDecimalOnly = (e) => {
    const reg = /^[0-9]*[.,]?[0-9]*$/;
    let preval = e.target.value;
    if (e.target.value === "" || reg.test(e.target.value)) return true;
    else e.target.value = preval.substring(0, preval.length - 1);
  };

  render() {
    return (
      <div className="container">
        <Modal
          {...this.props}
          size="lg"
          aria-labelledby="contained-modal-title-vcenter"
          centered
        >
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">
              Add Employee
            </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Row>
              <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                  <Form.Group controlId="Firstname">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control
                      type="text"
                      name="FirstName"
                      required
                      placeholder="First Name"
                    />
                  </Form.Group>

                  <Form.Group controlId="LastName">
                    <Form.Label>LastName</Form.Label>
                    <Form.Control
                      type="text"
                      name="Last Name"
                      required
                      placeholder="Last Name"
                    />
                  </Form.Group>

                  <Form.Group controlId="Email">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                      type="text"
                      name="Email"
                      required
                      placeholder="Email"
                    />
                  </Form.Group>

                  <Form.Group controlId="Department">
                    <Form.Label>Department</Form.Label>
                    <Form.Control as="select">
                      {this.state.departments.map((dep, index) => (
                        <option key={index}>{dep.DepartmentName}</option>
                      ))}
                    </Form.Control>
                  </Form.Group>

                  <Form.Group controlId="Salary">
                    <Form.Label>Salary</Form.Label>
                    <Form.Control
                      type="text"
                      name="Salary"
                      onChange={this.NumericDecimalOnly}
                      required
                      placeholder="Salary"
                    />
                  </Form.Group>

                  <Form.Group controlId="DateOfBirth">
                    <Form.Label>DateOfBirth</Form.Label>
                    <Form.Control
                      type="date"
                      name="DateOfBirth"
                      required
                      placeholder="DateOfBirth"
                    />
                  </Form.Group>

                  <Form.Group>
                    <Button
                      variant="primary"
                      type="submit"
                      style={{ marginTop: "10px" }}
                    >
                      Add Employee
                    </Button>
                  </Form.Group>
                </Form>
              </Col>
            </Row>
          </Modal.Body>

          <Modal.Footer>
            <Button variant="danger" onClick={this.props.onHide}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>
      </div>
    );
  }
}
