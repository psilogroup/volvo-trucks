import api from './api';

async function getTruck(id) {
    const response = await api.get('/Truck/' + id);
    return response;
}
async function getAll() {
  const response = await api.get('/Truck');
  return response;
}

async function create(truck) {
  const response = await api.post('/Truck', truck);
  return response;
}

async function update(id,truck) {
    const response = await api.put('/Truck/'+id, truck);
}

async function deleteTruck(id) {
    const response = await api.delete('/Truck/' + id);
}
export {getAll, create, getTruck, update, deleteTruck};