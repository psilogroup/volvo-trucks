import { Routes, Route, Link} from 'react-router-dom';
import ListTurck from './pages/listTruck/';
import NewTruck from './pages/newTruck/';
import EditTruck from './/pages/editTruck/';
import './App.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
function App() {
  return (
    <div className='container'>
      <Routes>
        <Route path="/" element={<ListTurck />} />
        <Route path="/new" element={<NewTruck />} />
        <Route path="/edit/:id" element={<EditTruck />} />
      </Routes>
    </div>
  );
}

export default App;
