import React, { useState, useEffect } from 'react';
import * as Yup from 'yup'
import { Form, Formik, ErrorMessage, Field } from 'formik'
import axios from 'axios'
import { baseUrl, claimDetails, companyDetails, createUser } from '../../Helpers/UrlHelper';
import { toast } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'//
import Submitbutton from '../Common/SubmitButton';


toast.configure()
const initialValues = {
    id: 0,
    firstName: '',
    lastName: '',
    emailId: '',
    mobileNumber: '',
    companyId: 0,
    claimHeadId: 0,
    userCode: '',
    isCarporateDebtor: false,
    isAcceptTermCondition: true,
    password: '',
    confirmPassword: ''
}

const validationScheme = Yup.object({
    firstName: Yup.string().required("First Name is required."),
    lastName: Yup.string().required("Last name is required"),
    userCode: Yup.string().required("User name is required."),
    password: Yup.string().required("Password is required."),
    confirmPassword: Yup.string()
        .oneOf([Yup.ref('password'), null], 'Passwords and Confirm Password do not match !')
})



const Register = (props) => {

    const [claimDetail, setclaimDetails] = useState([]);
    const [companyDetail, setcompanyDetails] = useState([]);
    const [isLoading, setisLoading] = useState(false);

    const GetClaimIds = async () => {
        debugger
        await axios.get(baseUrl + claimDetails).then(resp => {
            debugger
            setclaimDetails(resp.data.entities)
        }).catch(err => {
            console.log(err)
        })
    }

    const GetCompanyIds = async () => {
        await axios.get(baseUrl + companyDetails).then(resp => {
            debugger
            setcompanyDetails(resp.data.entities)
        }).catch(err => {
            console.log(err)
        })
    }

    const HandleSubmit = (values) => {
        console.log(values)
        setisLoading(true)
        debugger
        axios.post(baseUrl + createUser, values).then(resp => {
            console.log(resp)
            debugger
            toast.success("Thanks for Your registration  !", { position: toast.POSITION.TOP_CENTER })
        }).catch(err => {
            console.log(err);
        }).finally(() => {
            setisLoading(false)
        })
    }


    useEffect(async () => {
        await GetClaimIds()
        await GetCompanyIds()
    }, [])

    return (
        <div style={{ 'height': '100%' }}>
            <div className='col-md-2'></div>
            <div className='col-md-8'>
                <div className="box box-primary" style={{
                    'height': '800px'
                }}>
                    < div className="box-header" >
                        <h3 className="box-title">Register User</h3>
                    </div>
                    <Formik initialValues={initialValues} validationSchema={validationScheme} onSubmit={HandleSubmit}>
                        <Form>
                            <div className="box-body">
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>First Name</label>
                                        <Field
                                            type="text"
                                            className="form-control"
                                            id="firstName"
                                            name='firstName'
                                            placeholder="First Name"
                                        />
                                        <ErrorMessage name='firstName'>
                                            {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                        </ErrorMessage>
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Last Name</label>
                                        <Field
                                            type="text"
                                            className="form-control"
                                            id="lastName"
                                            name='lastName'
                                            placeholder="Last Name"
                                        />
                                        <ErrorMessage name='lastName'>
                                            {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                        </ErrorMessage>
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Email address</label>
                                        <Field
                                            type="text"
                                            className="form-control"
                                            id="emailId"
                                            name='emailId'
                                            placeholder="Enter email"
                                        />
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Mobile Number</label>
                                        <Field
                                            type="text"
                                            className="form-control"
                                            id="mobileNumber"
                                            name='mobileNumber'
                                            placeholder="Mobile Number"
                                        />
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Company Id</label>
                                        <Field as='select' id='companyId' name='companyId'
                                            className="form-control">
                                            <option>--Select--</option>
                                            {
                                                companyDetail.map(data => (<option value={data.id}>{data.name}</option>))
                                            }
                                        </Field>


                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Claim Head Id</label>
                                        <Field as='select' name='claimHeadId' id='claimHeadId'
                                            className="form-control">
                                            <option>--Select--</option>
                                            {claimDetail.map(data => (<option value={data.id}>{data.name}</option>))}
                                        </Field>
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>User Name</label>
                                        <Field
                                            type="text"
                                            className="form-control"
                                            id="userCode"
                                            name='userCode'
                                            placeholder="User name"
                                        />
                                        <ErrorMessage name='userCode'>
                                            {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                        </ErrorMessage>
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Password</label>
                                        <Field
                                            type="Password"
                                            className="form-control"
                                            id="password"
                                            placeholder="Password"
                                            name='password'
                                        />
                                        <ErrorMessage name='password'>
                                            {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                        </ErrorMessage>
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Confirm Password</label>
                                        <Field
                                            type="Password"
                                            className="form-control"
                                            id="confirmPassword"
                                            name='confirmPassword'
                                            placeholder="Confirm Password"
                                        />
                                        <ErrorMessage name='confirmPassword'>
                                            {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                        </ErrorMessage>
                                    </div>
                                </div>
                                <div className='col-md-6'>
                                    <div className="form-group">
                                        <label>Is Coperate Debetor</label>
                                        <Field as='select' name='isCarporateDebtor' id='isCarporateDebtor'
                                            className="form-control">
                                            <option value="true">Yes</option>
                                            <option value="true">No</option>
                                        </Field>
                                    </div>
                                </div>
                            </div>

                            <Submitbutton loading={isLoading}></Submitbutton>

                        </Form>
                    </Formik>

                </div>
            </div >
            <div className='col-md-2'></div>


        </div >

    );
}

export default Register;
