import { lazy } from "react";
const NewsletterSubscriptionTable = lazy(() => import("../components/newslettersubscriptionsform/NewsletterSubscriptionTable"));
const newsletterRoutes = [
  {
    path: "/newsletter/admin",
    name: "NewsletterSubscriptionTable",
    exact: true,
    element: NewsletterSubscriptionTable,
    roles: ["Admin"],
    isAnonymous: false,
  },
];

const allRoutes = [
  ...newsletterRoutes,
];

export default allRoutes;
