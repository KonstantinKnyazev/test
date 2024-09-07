import React, { Component, ChangeEvent } from "react";
import { User } from "../shared/User";

interface ExampleState {
    users: User[];
    displayedUsers: User[];
    currentPage: number;
    usersPerPage: number;
    searchTerm: string;
  }

export class Example extends React.Component <{}, ExampleState>{
    
    private users: User[] = [];

    constructor(props: {}) {
        super(props);
        this.state = {
          users: [],
          displayedUsers: [],
          currentPage: 1,
          usersPerPage: 30,
          searchTerm: ''
        };
      }

    public componentDidMount() {
        document.title = "Example - My React Application";
        this.loadUsers();
    }

    public render(): JSX.Element {

        const { displayedUsers, currentPage, usersPerPage, searchTerm } = this.state;

        // Pagination Logic
        const totalPages = Math.ceil(this.state.users.length / usersPerPage);
        const prevPage = () => this.setState(prevState => ({ currentPage: Math.max(prevState.currentPage - 1, 1) }));
        const nextPage = () => this.setState(prevState => ({ currentPage: Math.min(prevState.currentPage + 1, totalPages) }));
    
        // Filter Logic
        const filteredUsers = this.state.users.filter(user =>
          user.first_name.toLowerCase().includes(searchTerm.toLowerCase()) ||
          user.last_name.toLowerCase().includes(searchTerm.toLowerCase()) ||
          user.email.toLowerCase().includes(searchTerm.toLowerCase())
        );
    
        // Paginate filtered users
        const indexOfLastUser = currentPage * usersPerPage;
        const indexOfFirstUser = indexOfLastUser - usersPerPage;
        const currentUsers = filteredUsers.slice(indexOfFirstUser, indexOfLastUser);


        return (
            <div>
                <h2>Example</h2>
                <div className="row">
                    <div className="col-lg-12">
                        <input
                        type="text"
                        placeholder="Search..."
                        value={searchTerm}
                        onChange={this.handleSearchChange}
                        className="form-control mb-3"
                        />
                        <div className="tb-container" style={{ maxHeight: "400px", overflowY: "scroll" }}>
                            <table className="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>First Name</th>
                                        <th>Last Name </th>
                                        <th>Email</th>
                                        <th>Date Created</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {currentUsers.map(user => (
                                        <tr key={user.id}>
                                            <td>{user.id}</td>
                                            <td>{user.first_name}</td>
                                            <td>{user.last_name}</td>
                                            <td>{user.email}</td>
                                            <td>{new Date(user.date_created).toLocaleDateString('en-CA', {
                                                year: 'numeric',
                                                month: '2-digit',
                                                day: '2-digit'})}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                        {/* <button
                            className="btn btn-info"
                            type="button"
                            id="addressSearch"
                            onClick={() => this.loadUsers()}
                        >
                            Load Users
                        </button> */}
                        <div className="pagination mt-3">
              <button
                className="btn btn-secondary"
                onClick={prevPage}
                disabled={currentPage === 1}
              >
                Previous
              </button>
              <span className="mx-2">
                Page {currentPage} of {totalPages}
              </span>
              <button
                className="btn btn-secondary"
                onClick={nextPage}
                disabled={currentPage === totalPages}
              >
                Next
              </button>
            </div>
                    </div>
                </div>
            </div>
        );
    }

    private async loadUsers(): Promise<void>  {
        try {
            const response = await fetch("http://localhost:3000/User/GetUsers");
            const apiUsers = await response.json();
            this.setState({ users: apiUsers, displayedUsers: apiUsers });
          } catch (error) {
            console.error("Error loading users:", error);
          }
        // fetch("http://localhost:3000/User/GetUsersXXX")
        // .then(response => {
        //     response.json()
        //     .then(apiUsers => {
        //         this.users = apiUsers;
        //         this.forceUpdate();
        //     });
        // });
    };

    private handleSearchChange = (e: ChangeEvent<HTMLInputElement>): void => {
        this.setState({ searchTerm: e.target.value });
      };
}