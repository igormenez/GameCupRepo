import React from 'react'
import  Container from 'react-bootstrap/Container'
import  Row from 'react-bootstrap/Row'
import  Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Col from 'react-bootstrap/Col'
import { useSelector, useDispatch } from 'react-redux'
import './WinnerGames.css'

export default function WinnerGames () {
  
  const winnerGames = useSelector(state => state.games.winnerGames)
  const dispatch = useDispatch()

  function startNewCoup() {
    dispatch({ type: "START_GAME" })
  }

  return (
    <Container className={"info-games"}>
      <Row>
        <Col md={4}>
        </Col>
        <Col md={4}>
        </Col>
        <Col md={4}>
          <Button variant="dark" onClick={()=> startNewCoup()} >Iniciar nova copa</Button>
        </Col>
      </Row>
      {console.log(winnerGames)}
    <Row className={"winner-block pagination-centered"}>
          <Row>
            <div className="game-block">
                <div className="winner-flag">
                  <h4>1º</h4>
                </div>
                <div className="game-name">
                  {winnerGames[0].titulo}
                </div>
              </div>
          </Row>
          <Row>
            <div className="game-block">
              <div className="winner-flag">
                <h4>2º</h4>
              </div>
              <div className="game-name">
                {winnerGames[1].titulo}
              </div>
            </div>
          </Row>
    </Row>
    </Container>
  )
}