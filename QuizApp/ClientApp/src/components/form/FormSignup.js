import React, { useState } from 'react';
import './Form.css';
import FormSignupProps from './FormSignupProps';
import FormSuccess from './FormSuccess';
import Logo from '../../assets/KozzQuiz_logo_svg.svg';


const FormSignup = () => {
  const [isSubmitted, setIsSubmitted] = useState(false);

  function submitForm() {
    setIsSubmitted(true);
  }
  return (
    <>
      <div className='form-container'>
        
        <div className='form-content-left'>
          <img className='form-img' src={Logo} alt='kozz_logo' />
        </div>
        {!isSubmitted ? (
          <FormSignupProps submitForm={submitForm} />
        ) : (
          <FormSuccess />
        )}
      </div>
    </>
  );
};

export default FormSignup;