import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import styles from './Matches.modules.css';

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
        return this.state.matches.map((match, index) => {
            const { id, homeTeamName, awayTeamName, date, round } = match;
            return (
                <tr key={index}>
                    <td>{homeTeamName}</td>
                    <td>{awayTeamName}</td>
                    <td>{date}</td>
                    <td>{round}</td>
                    <td><Link className="button" to={`/match/${id}`}>View Match Details</Link></td>
                </tr>
            );
        });
    }

    render() {
        const { loading, matches } = this.state;
        return (
            <div className="container matches">
                <h1 className="title">Matches</h1>
                <p className="subtitle">This component demonstrates fetching data from the server.</p>
                {loading ? (
                    <p>Loading...</p>
                ) : matches.length > 0 ? (
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Home Team</th>
                                <th>Away Team</th>
                                <th>Date</th>
                                <th>Round</th>
                                <th></th>
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
