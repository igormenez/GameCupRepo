import './App.css';
import Home from './pages/home/Home'
import { Provider } from 'react-redux'
import store from '../store/index'

function App() {
  return (
    <Provider store={store}>
      <Home/>
    </Provider>
  );
}

export default App;
