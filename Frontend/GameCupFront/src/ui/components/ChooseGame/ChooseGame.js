import React, { useState } from 'react'
import * as repository from '../../../data/repositories/games_repositories'
import  Container from 'react-bootstrap/Container'
import  Row from 'react-bootstrap/Row'
import  Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Col from 'react-bootstrap/Col'
import { useSelector, useDispatch } from 'react-redux'
import "./ChooseGame.css"

export default function ChooseGame () {
  let [games, setGames] = useState();
  let [selectedGames, setSelectedGames] = useState([]);
  let [errorMessage, setErrorMessage] = useState(undefined);
  let [keys, setkeys] = useState();
  
  const games_redux = useSelector(state => state.games)
  const dispatch = useDispatch()

  React.useEffect(() => {
    repository.getGames()
      .then(games => {
        const groups = games.reduce((groups, item) => {
          const group = ( groups[item.ano] || []);
          group.push(item);
          groups[item.ano] = group;
          return groups;
        }, {});
      
        var keys = Object.keys(groups);
      
        console.log(groups)
        setGames(groups)
      })
      .catch((e) => console.log(e))
    }, [])


    function toggleGame(game_id) {
      let game = games.find(game => game.id === game_id)

      if (errorMessage != undefined){
        setErrorMessage(undefined)
      }
      if(!selectedGames.includes(game) && selectedGames.length < 8 ){
        setSelectedGames([...selectedGames,game])
      }else{
        setSelectedGames(selectedGames.filter((e)=>(e !== game)))
      }
    }

    function startCoup(){
      if(selectedGames.length == 8 ){
        repository.startCoup(selectedGames).then(winnerGames => 
        dispatch({ type: "ADD_WINNERS", winnerGames: winnerGames})).catch((e) => console.log(e))
      }else{
        setErrorMessage("Selecione 8 jogos!")
      }
    }
  return (
    <Container>
      <Row className={"info-games"}>
        <Col md={4}>
          <h3>{selectedGames.length} Games Selecionados</h3>
        </Col>
        <Col md={4}>
          <div id={errorMessage == undefined ? "hide-error" : null } role="alert">
            {errorMessage}
          </div>
        </Col>
        <Col md={4}>
          <Button variant="dark" onClick={() => startCoup()}>Gerar Meu Campeonato</Button>
        </Col>
      </Row>
      <Container className="games-block align-items-center">
        <Row className={" container "}>
         {/* {games?.map(ano => {
           return ( */}
             {games?.map(game => {
               return(
                 <Card style={{ width: '18rem' }} id="cards" className={ selectedGames.includes(game)? "card-game" : null} key={game.id} onClick={()=> toggleGame(game.id)} >
                   <Card.Body >
                     <div className="form-check">
                       <input className="form-check-input" type="checkbox" checked={selectedGames.includes(game)? true : false } readOnly id="flexCheckDefault"></input>
                     </div>
                     <Card.Title>{game.titulo}</Card.Title>
                       <Card.Subtitle className="mb-2 text-muted"><img src={game.urlImagem} className="img-thumbnail" alt={game.titulo}></img></Card.Subtitle>
                     <Card.Text>
                     </Card.Text>
                   </Card.Body>
                 </Card>
             )
             })}        
           
           {/* )})} */}
         
       </Row>
      </Container>
    </Container>
  )
}
