import * as Yup from 'yup'
const newsletterFormValidation = Yup.object({
email: Yup.string().email('Invalid email address').required('Email is required'),
});

export default newsletterFormValidation;
