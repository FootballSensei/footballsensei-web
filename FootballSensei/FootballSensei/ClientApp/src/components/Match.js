import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import styles from './Match.modules.css';

function Match() {
    const { id } = useParams();
    const { round } = useParams();
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
    }, [id, round]);

    const formatMatch = (match) => {
        return `${match.homeTeamName} ${match.homeGoals} - ${match.awayGoals} ${match.awayTeamName}`;
    }

    return (
        <div>
            <h1>Superliga - Runda {match?.round}</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {loading ? (
                <p>Loading...</p>
            ) : match ? (
                <div className="match-card">
                    <div className="match-details">
                        <div className="match-score">{formatMatch(match)}</div>
                        <div className="match-date">{match.date}</div>
                    </div>
                </div>
            ) : (
                <p>No matches found.</p>
            )}
        </div>
    );
}

export default Match;
