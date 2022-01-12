const INITIAL_STATE = {
  winnerGames: [],
  beginingGame: true
}

const games = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case 'START_GAME':
      return {
        winnerGames: [],
        beginingGame: true
      }
    case 'ADD_WINNERS':
      return{
        winnerGames: action.winnerGames,
        beginingGame: false
      }
    default:
      return state
  }
}

export default games
