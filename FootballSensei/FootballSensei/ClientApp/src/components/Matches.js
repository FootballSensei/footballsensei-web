import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Matches extends Component {
    constructor(props) {
        super(props);
        this.state = {
            matches: [],
            loading: true
        };
    }

    async componentDidMount() {
        const response = await fetch('api/match');
        const data = await response.json();
        this.setState({ matches: data, loading: false });
    }

    renderTableData() {
        console.log(this.state.matches);
        return this.state.matches.map((match, index) => {
            const { id, homeTeamName, awayTeamName, date } = match;
            return (
                <><tr key={index}>
                    <td>{homeTeamName}</td>
                    <td>{awayTeamName}</td>
                    <td>{date}</td>
                </tr>
                <Link to={`/match/${id}`}>View Match Details</Link></>

            );
        });
    }

    render() {
        const { loading, matches } = this.state;
        console.log(matches);
        return (
            <div>
                <h1>Matches</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {loading ? (
                    <p>Loading...</p>
                ) : matches.length > 0 ? (
                    <table>
                        <thead>
                            <tr>
                                <th>Home Team</th>
                                <th>Away Team</th>
                                <th>Date</th>
                            </tr>
                        </thead>
                        <tbody>{this.renderTableData()}</tbody>
                    </table>
                    
                ) : (
                    <p>No matches found.</p>
                )}
            </div>
        );
    }

}