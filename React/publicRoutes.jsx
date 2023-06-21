import { lazy } from "react";
const NewsletterSubscriptionsForm = lazy(() => import("../components/newslettersubscriptionsform/NewsletterSubscriptionsForm"));
const newsletterRoutes = [
  {
    path: "/newsletter/create",
    name: "Newsletter Form",
    exact: true,
    element: NewsletterSubscriptionsForm,
    roles: [],
    isAnonymous: true,
  },
  var allRoutes = [
  ...newsletterRoutes,
];
export default allRoutes;
