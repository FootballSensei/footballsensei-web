import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

function Match() {
    const { id } = useParams();
    const [match, setMatch] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function fetchMatch() {
            const response = await fetch(`api/match/getMatchById/${id}`);
            const data = await response.json();
            setMatch(data);
            setLoading(false);
        }

        fetchMatch();
    }, [id]);

    return (
        <div>
            <h1>Match {id}</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {loading ? (
                <p>Loading...</p>
            ) : match ? (
                <table>
                    <thead>
                        <tr>
                            <th>Home Team</th>
                            <th>Away Team</th>
                            <th>Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>{match.homeTeamName}</td>
                            <td>{match.awayTeamName}</td>
                            <td>{match.date}</td>
                        </tr>
                    </tbody>
                </table>
            ) : (
                <p>No matches found.</p>
            )}
        </div>
    );
}

export default Match;
