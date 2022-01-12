import Axios from 'axios'

class Http {

  static getInstance () {
    if (!Http.instance) {
      Http.instance = Axios.create({
        headers: {
          'Content-type': 'application/json'
        }
      })
    }
    return Http.instance
  }
}

export default Http

export const http = Http.getInstance()
