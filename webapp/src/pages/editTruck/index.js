import React, { useEffect, useState } from 'react';
import { useNavigate,useParams } from 'react-router-dom'
import {getTruck,update} from '../../services/truckService';
import './style.css'

export default function () {
    const [model, setModel] = useState('FM');
    const [modelYear, setModelYear] = useState(0);
    const [manufacturingYear, setManufacturingYear] = useState(0);
    const navigate = useNavigate();
    const {id} = useParams();

    function loadTruck(){
        getTruck(id).then(response => {
            console.log(response.data);
            setModel(response.data.model);
            setModelYear(response.data.modelYear);
            setManufacturingYear(response.data.manufacturingYear);
        });
    }

    useEffect(() => {
        loadTruck();
    },[]);

    function saveTruck(){
        let payload = {
            model: model,
            modelYear: modelYear,
            manufacturingYear: manufacturingYear
        };

        console.log('payload', payload);
        update(id,payload).then(response => {
            alert('Truck updated successfully');
            navigate('/');

        }).catch(error => {
            console.log('error', error);
            alert(error.response.data);
        });

    }
    return (
        <div className='col-md-12'>
                <div className='row'>
                    <div className="form-group">
                        <label>Model</label>
                        <select  name="model" className='form-control' onChange={e => setModel (e.target.value) } value={model}>
                            <option value="FM" selected>FM</option>
                            <option value="FH">FH</option>
                        </select>
                    </div>
                
                <div className='row'>
                    <label>Model Year</label>
                    <input type="text" name="modelYear" className='form-control' onChange={(e) => setModelYear(e.target.value)} value={modelYear} />
                </div>
                <div className='row'>
                    <label>Manufacturing Year</label>
                    <input type="text" name="manufacturingYear" className='form-control' onChange={(e) => setManufacturingYear(e.target.value)} value={manufacturingYear} />
                </div>
            </div>
            <div className='row'>
                <button className='btn btn-primary' onClick={ () => saveTruck()}>Save</button>
            </div>
        </div>
        )
}