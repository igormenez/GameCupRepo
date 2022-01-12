import Http from '../utils/Http'
import * as ApiRoutes from '../utils/ApiRoutes'

const http = Http.getInstance()

export async function getGames() {
  const resp = await http.get(ApiRoutes.getGames)  
  return resp.data
}

export async function startCoup(selecredGames){
  const resp = await http.post(ApiRoutes.startCoup, selecredGames)  
  return resp.data
}
