import React from 'react';
import './Form.css';
import Happy_Owl from '../../assets/Happy_Owl.gif';

const FormSuccess = () => {
  return (
    <div className='form-content-right'>
      <h1 className='form-success'>Your Account was created successfully!</h1>
      <img className='form-img-2' src={Happy_Owl} alt='success' />
    </div>
  );
};

export default FormSuccess;