import React, { Component } from 'react';

export class Matches extends Component {
    static displayName = Matches.name;

    constructor(props) {
        super(props);
        this.state = { matches: [], loading: true };
    }

    componentDidMount() {
        this.populateMatchesData();
    }

    static renderMatchesTable(matches) {
        return (
            <table className='table table-striped' aria-labelledby='tableLabel'>
                <thead>
                    <tr>
                        <th>Home Team</th>
                        <th>Away Team</th>
                        <th>Match Date</th>
                    </tr>
                </thead>
                <tbody>


                    {matches.map(match =>
                        <tr key={match.Id}>
                            <td>{match.HomeTeamName}</td>
                            <td>{match.AwayTeamName}</td>
                            <td>{match.Date}</td>
                        </tr>
                    )}

                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Matches.renderMatchesTable(this.state.matches);

        return (
            <div>
                <h1 id='tableLabel'>Matches</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateMatchesData() {
        const response = await fetch('matches');
        const data = await response.json();
        this.setState({ matches: data, loading: false });
    }
}
