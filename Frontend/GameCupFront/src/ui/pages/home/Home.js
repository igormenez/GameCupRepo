import * as React from 'react';
import HeaderSelection from '../../components/HeaderSelection/HeaderSelection'
import HeaderWinner from '../../components/HeaderWinner/HeaderWinner'
import ChooseGame from '../../components/ChooseGame/ChooseGame'
import WinnerGames from '../../components/WinnerGames/WinnerGames'
import { useSelector } from 'react-redux'

export default function Home () {

  const begining = useSelector(state => state.games.beginingGame)
  return (
    <>
      {begining?
      <>
        <HeaderSelection/>
        <ChooseGame/>
      </>
      :
      <>
        <HeaderWinner/>
        <WinnerGames/>
      </>
    }
    </>
  )
}
