import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import styles from './Match.modules.css';

function Match() {
    const { homeTeam } = useParams();
    const { awayTeam } = useParams();
    const [match, setMatch] = useState(null);
    const [loading, setLoading] = useState(true);
    const [prediction, setPrediction] = useState(null);

    const winnerClass = "winner";
    const loserClass = "loser";

    useEffect(() => {
        async function fetchMatch() {
            const response = await fetch(`api/lineupdatum/match/${homeTeam}/${awayTeam}`);
            const data = await response.json();
            setMatch(data);

            const response2 = await fetch(`api/matchdatum/prediction/${homeTeam}/${awayTeam}`, {
                method: 'POST'
            });
            console.log(response2);
            const data2 = await response2.json();
            console.log(data2);
            setPrediction(data2);
            setLoading(false);
        }

        fetchMatch();
    }, [homeTeam, awayTeam]);

    const formatMatch = (match) => {
        // return `${match.homeTeam} ${match.homeSentiment} - ${match.awaySentiment} ${match.awayTeam}`;
        return `${match.homeTeam} - ${match.awayTeam}`;
    }

    const formatSentiment = (match) => {
        // return the 2 sentiments on different lines
        return `${match.homeTeam} overall sentiment score: ${match.homeSentiment} - ${match.awayTeam} overall sentiment score: ${match.awaySentiment}`;
    }

    const formatStrongestSentiment = (match) => {
        // return the strongest sentiment
        // make 4 variables for home_positive_score, home_negative_score, away_positive_score, away_negative_score
        // take the greatest of the 4 variables
        // return something like 'StrongestSentiment: TheNameOfTheTeam with a score of TheScore'

        var home_positive_score = match.homePositiveScore;
        var home_negative_score = match.homeNegativeScore;
        var away_positive_score = match.awayPositiveScore;
        var away_negative_score = match.awayNegativeScore;

        // If all 4 scores are 0, return "No sentiment detected"
        if (home_positive_score === 0 && home_negative_score === 0 && away_positive_score === 0 && away_negative_score === 0) {
            return "No sentiment detected";
        }

        // Found the maximum score
        var max_score = Math.max(home_positive_score, home_negative_score, away_positive_score, away_negative_score);

        // If the max_score is 0, then it means that surely there is a negative score, so return the team with the lowest negative score
        if (max_score === 0) {
            if (home_negative_score < away_negative_score) {
                return (
                    <span className={`${loserClass}`}>
                        Predicted loser: {match.homeTeam} with a negative score of {home_negative_score}
                    </span>
                );
            } else {
                return (
                    <span className={`${loserClass}`}>
                        Predicted loser: {match.awayTeam} with a negative score of {away_negative_score}
                    </span>
                );
            }
        } else {
            // If the max_score is not 0, then return the team with the highest score
            if (home_positive_score > away_positive_score) {
                return (
                    <span className={`${winnerClass}`}>
                        Predicted winner: {match.homeTeam} with a positive score of {home_positive_score}
                    </span>
                );
            } else {
                return (
                    <span className={`${winnerClass}`}>
                        Predicted winner: {match.awayTeam} with a positive score of {away_positive_score}
                    </span>
                );
            }
        }
    };


    const formatFormations = (lineup) => {
        return lineup.replace(/[\[\]"']/g, '').split(", ");
    };
    
    return (
        <div>
            <h1>Premier League</h1>
            {loading ? (
                <p>Loading...</p>
            ) : match ? (
                    <div className="match-card">
                    <div className="match-date">{match.date.replace("T00:00:00", "").replace("-", "/").replace("-", "/")}</div>
                    <div className="match-score">{formatMatch(match)}</div>
                    <div className="match-sentiment">{formatSentiment(match)}</div>
                    <div className="match-strongest-sentiment">{formatStrongestSentiment(match)}</div>
                    <div className="match-details">
                        <div className="team-section">
                            <div className="team-name-sentiment">
                                <span className="team-name">{match.homeTeam}</span>
                            </div>
                            <div className="team-players">
                                {formatFormations(match.homeLineup).map((player, index) => (
                                    <div className={`player position-${index}`}>{player}</div>
                                ))}
                            </div>
                        </div>
                        <div className="team-section">
                            <div className="team-name-sentiment">
                                <span className="team-name">{match.awayTeam}</span>
                            </div>
                            <div className="team-players">
                                {formatFormations(match.awayLineup).map((player, index) => (
                                    <div className={`player position-${index}`}>{player}</div>
                                ))}
                            </div>
                        </div>
                        {/* <div className="match-prediction">{prediction.score}</div> */}
                    </div>
                </div>
            ) : (
                <p>No matches found.</p>
            )}
        </div>
    );
}

export default Match;
