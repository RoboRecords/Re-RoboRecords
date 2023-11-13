// function loadRuns(categoryId) {
//     fetch('/Leaderboard/Runs?categoryId=' + categoryId)
//         .then(response => response.json())
//         .then(data => {
//             const runsTableBody = document.querySelector('#runs tbody');
//             runsTableBody.innerHTML = ''; // Clear current runs
//
//             data.forEach(run => {
//                 const tr = document.createElement('tr');
//                 tr.innerHTML = `
//                     <td>${run.playerName}</td>
//                     <td>${run.time}</td>
//                     <td>${run.characterName}</td>
//                     <td>${run.levelName}</td>
//                     <td>${new Date(run.dateSubmitted).toLocaleDateString()}</td>
//                     <td>${run.videoUrl ? `<a href="${run.videoUrl}" target="_blank">Watch</a>` : ''}</td>
//                 `;
//                 runsTableBody.appendChild(tr);
//             });
//         })
//         .catch(error => console.error('Error loading runs:', error));
// }
