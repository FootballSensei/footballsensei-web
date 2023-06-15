import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import styles from './Match.modules.css';

function Match() {
    const { homeTeam } = useParams();
    const { awayTeam } = useParams();
    const [match, setMatch] = useState(null);
    const [loading, setLoading] = useState(true);
    const [prediction, setPrediction] = useState(null);

    useEffect(() => {
        async function fetchMatch() {
            const response = await fetch(`api/lineupdatum/match/${homeTeam}/${awayTeam}`);
            const data = await response.json();
            setMatch(data);

            const response2 = await fetch(`api/matchdatum/prediction/${homeTeam}/${awayTeam}`);
            const data2 = await response2.json();
            setPrediction(data2);
            setLoading(false);
        }

        fetchMatch();
    }, [homeTeam, awayTeam]);

    const formatMatch = (match) => {
        return `${match.homeTeam} ${match.homeSentiment} - ${match.awaySentiment} ${match.awayTeam}`;
    }

    const formatFormations = (lineup) => {
        let homeLineupFormatted = '';
        for (let i = 0; i < lineup.length; i++) {
            if (lineup[i] != '[' || lineup[i] != ']') {
                if (lineup[i] == ',')
                    homeLineupFormatted += ', ';
                else
                    homeLineupFormatted += lineup[i];
            }
                
        }

        

        return `${homeLineupFormatted.replace(/"/g, '').replace("[", '').replace("]", '')}`;
    };


    return (
        <div>
            <h1>Premier League</h1>
            {loading ? (
                <p>Loading...</p>
            ) : match ? (
                <div className="match-card">
                    <div className="match-details">
                        <div className="match-score">{formatMatch(match)}</div>
                            <div className="match-date">{match.date}</div>
                            <div className="match-formations">{formatFormations(match.homeLineup)}</div>
                            <br></br>
                            <div className="match-formations">{formatFormations(match.awayLineup)}</div>
                            <div className="match-prediction">{prediction}</div>
                    </div>
                </div>
            ) : (
                <p>No matches found.</p>
            )}
        </div>
    );
}

export default Match;
