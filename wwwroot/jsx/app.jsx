import React, { useState, useEffect } from 'react';

const Leaderboard = () => {
    const [leaderboardData, setLeaderboardData] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        // Replace with your actual endpoint
        fetch('/Leaderboards/GetAllRunsForGame?gameName="')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => setLeaderboardData(data))
            .catch(error => {
                setError(error.message);
                console.error('There was a problem with the fetch operation:', error);
            });
    }, []);

    return (
        <div className="container mt-4">
            <h2>Leaderboard</h2>
            {error && <div className="alert alert-danger" role="alert">{error}</div>}
            <table className="table">
                <thead>
                <tr>
                    <th>Rank</th>
                    <th>Player</th>
                    <th>Time</th>
                    <th>Character</th>
                    <th>Date</th>
                </tr>
                </thead>
                <tbody>
                {leaderboardData.map((entry, index) => (
                    <tr key={entry.id}>
                        <td>{index + 1}</td>
                        <td>{entry.player}</td>
                        <td>{entry.time}</td>
                        <td>{entry.character}</td>
                        <td>{new Date(entry.date).toLocaleDateString()}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
};

export default Leaderboard;
