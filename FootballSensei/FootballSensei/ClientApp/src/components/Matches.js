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
        const response = await fetch('api/lineupdatum');
        const data = await response.json();
        this.setState({ matches: data, loading: false });
    }

    renderTableData() {
        const sortedMatches = this.state.matches.sort((a, b) => {
            // Convert date strings to Date objects for comparison
            const dateA = new Date(a.date);
            const dateB = new Date(b.date);

            // Compare the date objects
            return dateA - dateB;
        });

        return sortedMatches.map((match, index) => {
            const { date, homeTeam, awayTeam, homeLineup, awayLineup, homeSentiment, awaySentiment,
                homePositiveScore, homeNegativeScore, awayPositiveScore, awayNegativeScore } = match;
            return (
                <tr key={index}>
                    <td>{homeTeam}</td>
                    <td>{awayTeam}</td>
                    <td>{date}</td>
                    <td><Link className="button" to={`/match/${homeTeam}/${awayTeam}`}>View Match Details</Link></td>
                </tr>
            );
        });
    }


    render() {
        const { loading, matches } = this.state;
        return (
            <div className="container matches">
                <h1 className="title">Matches</h1>
                {loading ? (
                    <p>Loading...</p>
                ) : matches.length > 0 ? (
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Home Team</th>
                                <th>Away Team</th>
                                <th>Date</th>
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
