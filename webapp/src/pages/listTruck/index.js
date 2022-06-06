import React, { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom'
import { Link } from 'react-router-dom'
import './style.css'
import { getAll,deleteTruck } from '../../services/truckService';

export default function ListTruck() {
    const [trucks, setTrucks] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getAll().then(response => {
            setTrucks(response.data);
        });
    },[]);

    function editTruck(id){
        navigate('/edit/' + id);
    }

        function removeTruck(id) {
            if (window.confirm('Are you sure?')) {
                deleteTruck(id).then(response => {
                    alert('Truck deleted successfully');
                    getAll().then(response => {
                        setTrucks(response.data);
                    });
                }).catch (error => {
                    console.log('error', error);
                    alert(error.response.data);
                });
        }
    }

    return (
        <div className='col-md-12'>
            <div className='row'>
                
                <Link to="/new" className='btn btn-primary'>New Truck</Link>
            </div>
            <div className='row'>
                <table className='table'>
                    <thead>
                        <tr>
                            <th>Model</th>
                            <th>Model Year</th>
                            <th>Manufacturer Year</th>
                            <th>
                                Actions
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                        trucks.map(t => {
                            return (<tr>
                                    <td>{t.model}</td>
                                    <td>{t.modelYear}</td>
                                    <td>{t.manufacturingYear}</td>
                                    <td>
                                        <button type='button' className='btn btn-primary' onClick={e => {editTruck(t.id)}} >edit</button>
                                        <button type='button' className='btn btn-danger' onClick={e => {removeTruck(t.id); }} >delete</button> 
                                    </td>
                                </tr>
                            )
                        })
                    }
                    
                    </tbody>
                </table>
            </div>

            
        </div>
    )
}