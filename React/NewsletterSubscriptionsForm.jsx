import  React from 'react';
import { useNavigate } from 'react-router-dom';
import './NewsletterSubscriptions.css';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import newsletterFormValidation from 'schemas/newsletterFormSchema';
import * as newsletterSubscriptionFormService from 'services/newsletterSubscriptionFormService';
import { Button } from 'react-bootstrap';
import Swal from 'sweetalert2';

function NewsletterSubscriptions() {
const handleSubmit = (values, { setSubmitting , resetForm}) => {
  newsletterSubscriptionFormService.addEmailToSubscription(values.email)
    .then(onEmailSuccess)
    .catch(onEmailFail)
    .finally(() => {
    setSubmitting(false);
    resetForm();
    })
  };
  const navigate = useNavigate();
  
const onEmailSuccess = () =>{
  Swal.fire("Thank You For Applying!", "Email added successfully!").then(() => {
    navigate("/")
    })
  console.log("Email added successfully!");
}

const onEmailFail = () => {
  Swal.fire("Thank You!", "Your Email is already subscribed!")
  console.log("Error adding email:");
}

return (
  <div className="newsletter-subscriptions">
    <div className="newslettersubscriptions-container">
      <div className="row">
        <div className="col-sm-12">
          <div className="content">
            <h2 className="newsletter-header">Newsletter Subscription</h2>
            <Formik
              initialValues={{ email: '' }}
              validationSchema={newsletterFormValidation}
              onSubmit={handleSubmit}
              name="newsletterForm"
            >
              {({ errors, touched }) => (
                <Form>
                  <div className="form-group">
                    <h6 className="newsletter-email-text">Enter your email</h6>
                    <div className="newsletter-input-group">
                      <Field
                        type="email"
                        name="email"
                        className={`newsletter-form-control ${
                          errors.email && touched.email ? 'newsletter-is-invalid' : ''
                        }`}
                        placeholder="Enter email to subscribe"
                      />
                      <Button className="newsletter-btn-success" type="submit">
                        Subscribe
                      </Button>
                    </div>
                    <ErrorMessage
                      name="email"
                      component="div"
                      className="error text-danger"
                    />
                  </div>
                </Form>
              )}
            </Formik>
            <div className="text-center">
              <a className="newsletter-link" href="">
                Want the latest news? Get it in your inbox.
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
);
}

export default NewsletterSubscriptions;
