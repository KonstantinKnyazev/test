import React, { Component , ChangeEvent, FormEvent} from "react";
import { UserDTO } from '../shared/User'; // Import the UserDTO class


// Define the interface for the component's state
interface UserFormState {
    first_name: string;
    last_name: string;
    email: string;
    date_created: string;
    message: string;
  }
export class Exam extends React.Component<{}, UserFormState> {
    //private userDTO: UserDTO = new UserDTO;
    
    constructor(props: {}) {
        super(props);
        this.state = {
          first_name: '',
          last_name: '',
          email: '',
          date_created: '',
          message: '',
        };
      }
        

      handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        this.setState({ [e.target.name]: e.target.value } as any); // Type assertion to handle dynamic property names
      };

      handleSubmit = async (e: FormEvent) => {
        e.preventDefault();
    
        if (!this.state.first_name || !this.state.email) {
          this.setState({ message: "First name and email are required." });
          return;
        }
    
        const userDTO = new UserDTO;
        // (
        //   this.state.first_name,
        //   this.state.last_name,
        //   this.state.email,
        //    : undefined
        // );
        userDTO.first_name = this.state.first_name;
        userDTO.last_name = this.state.last_name;
        userDTO.email = this.state.email;
        userDTO.date_created =   new Date();
    
        try {

            

          const response = await fetch('http://localhost:3000/User/InsertUser', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(userDTO),
          });

          //const responseBody = await response.json(); // Parse the response body
    
          if (response.ok) {
            const rawText = await response.text(); // Parse the response body
            this.setState({ message: rawText || "User created successfully!", first_name: '', last_name: '', email: '', date_created: '' });
          } else {
            const rawText = await response.text(); // Parse the response body
            console.error('Raw response text:', rawText);
            this.setState({ message: rawText || "Failed to create user." });
          }
        } catch (error) {
          console.error('Error creating user:', error);
          this.setState({ message: "An error occurred while creating the user." });
        }
      };
    
    
    public componentDidMount() {
        document.title = "Exam - My React Application";
    }

    public render() {
        return (
            
            <form onSubmit={this.handleSubmit}>
            
                <div className="row">
                    <div className="col-lg-2">
                        <label>First Name:</label></div>                        
              
                    <div className="col-lg-2">
                        <input
                            type="text"
                            name="first_name"
                            value={this.state.first_name}
                            onChange={this.handleChange}
                            required/></div> 
                </div>             
            
                            
                <div className="row">
                    <div className="col-lg-2">
                        <label>Last Name:</label></div>
                    <div className="col-lg-2">
                        <input
                            type="text"
                            name="last_name"
                            value={this.state.last_name}
                            onChange={this.handleChange}/></div>
                </div>
            
            
                <div className="row">
                    <div className="col-lg-2">
                        <label>Email:</label></div>
                    <div className="col-lg-2">
                        <input
                            type="email"
                            name="email"
                            value={this.state.email}
                            onChange={this.handleChange}
                            required/></div>
                </div>
                        
            
                    {/* <div>
                    <label>Date Created:</label>
                    <input
                        type="datetime-local"
                        name="date_created"
                        value={this.state.date_created}
                        onChange={this.handleChange}
                    />
                    </div> */}
                <div className="row">
                    <div className="col-lg-4">  
                        <button type="submit">Create User</button></div>
                </div>

                <div className="row">
                    <div className="col-lg-4">
                        <p>{this.state.message}</p></div>
                </div>

           
          </form>
        );
    }
}
