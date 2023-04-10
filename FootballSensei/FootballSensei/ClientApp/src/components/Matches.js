import React, { Component } from 'react';

export class Matches extends Component {
    constructor(props) {
        super(props);
        this.state = {
            matches: [],
            loading: true
        };
    }

    async componentDidMount() {
        const response = await fetch('api/Match');
        const data = await response.json();
        this.setState({ matches: data, loading: false });
    }

    renderTableData() {
        return this.state.matches.map((match, index) => {
            const { homeTeamName, awayTeamName, date } = match;
            return (
                <tr key={index}>
                    <td>{homeTeamName}</td>
                    <td>{awayTeamName}</td>
                    <td>{date}</td>
                </tr>
            );
        });
    }

    render() {
        const { loading } = this.state;
        return (
            <div>
                <h1>Matches</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {loading ? (
                    <p>Loading...</p>
                ) : (
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
                )}
            </div>
        );
    }
}