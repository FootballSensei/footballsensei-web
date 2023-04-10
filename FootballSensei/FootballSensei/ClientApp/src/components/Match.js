import React, { Component } from 'react';

export class Match extends Component {
    constructor(props) {
          
        super(props);  
        this.state = { match: null , loading: true };  
    }


    async componentDidMount() {
        const response = await fetch('api/match');
        const data = await response.json();
        this.setState({ match: data, loading: false });
    }

    render() {
        const { loading, match } = this.state;
        console.log(match);
        return (
            <div>
                <h1>Matches</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {loading ? (
                    <p>Loading...</p>
                ) : match.length > 0 ? (

                    <table>
                        <thead>
                            <tr>
                                <th>Home Team</th>
                                <th>Away Team</th>
                                <th>Date</th>
                            </tr>

                        </thead>

                        <tbody>
                            {this.state.match.map((match, index) => {
                                const { homeTeamName, awayTeamName, date } = match;
                                return (
                                    <tr key={index}>
                                        <td>{homeTeamName}</td>
                                        <td>{awayTeamName}</td>
                                        <td>{date}</td>
                                    </tr>
                                )
                            }
                            )}

                        </tbody>

                    </table>

                ) : (

                    <p>No matches found.</p>

                )}

            </div>

        );


    }

}
