import React, { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom'
import {create} from '../../services/truckService';
import './style.css'

export default function () {
    const [model, setModel] = useState('FM');
    const [modelYear, setModelYear] = useState(0);
    const [manufacturingYear, setManufacturingYear] = useState(0);
    const navigate = useNavigate();
    function saveTruck(){
        let payload = {
            model: model,
            modelYear: modelYear,
            manufacturingYear: manufacturingYear
        };

        console.log('payload', payload);
        create(payload).then(response => {
            alert('Truck created successfully');
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
                        <select  name="model" className='form-control' onChange={e => setModel (e.target.value) }>
                            <option value="FM" selected>FM</option>
                            <option value="FH">FH</option>
                        </select>
                    </div>
                
                <div className='row'>
                    <label>Model Year</label>
                    <input type="text" name="modelYear" className='form-control' onChange={(e) => setModelYear(e.target.value)} />
                </div>
                <div className='row'>
                    <label>Manufacturing Year</label>
                    <input type="text" name="manufacturingYear" className='form-control' onChange={(e) => setManufacturingYear(e.target.value)} />
                </div>
            </div>
            <div className='row'>
                <button className='btn btn-primary' onClick={ () => saveTruck()}>Save</button>
            </div>
        </div>
        )
}