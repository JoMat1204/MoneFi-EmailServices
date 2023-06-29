import React, { useEffect, useState } from "react";
import { listAll, listSubscribed, searchPagination } from "services/newsletterSubscriptionFormService";
import NewsletterSubscriptionsTableTheme from "./NewsletterSubscriptionsTableTheme";
import toastr from "toastr";

const NewsletterSubscriptionTable = () => {
const [subscribedUsers, setSubscribedUsers] = useState({ array: [] });
const [showSubscribedOnly] = useState(false);
const [pageData] = useState({ pageIndex: 0, pageSize: 100 });
const [searchQuery, setSearchQuery] = useState("");

useEffect(() => {
  loadSubscribedUsers();
}, [showSubscribedOnly, pageData.pageIndex, pageData.pageSize, searchQuery]);

const onListSubscribedSuccess = (response) => {
  const newUsers = response.item.pagedItems;
  setSubscribedUsers((prevState) => {
    const newState = { ...prevState };
    newState.array = newUsers;
    return newState;
  });
  toastr.success("Subscribed users loaded successfully.");
};

const onListSubscribedError = (error) => {
  toastr.error("Failed to load subscribed users.", error);
};

const onListAllSuccess = (response) => {
  const newUsers = response.item.pagedItems;
  setSubscribedUsers((prevState) => {
    const newState = { ...prevState };
    newState.array = newUsers;
    return newState;
  });
  toastr.success("All users loaded successfully.");
};

const onListAllError = (error) => {
  toastr.error("Failed to load all users.", error);
};

const onSearchPaginationSuccess = (response) => {
  const newUsers = response.item.pagedItems;
  setSubscribedUsers((prevState) => {
    const newState = { ...prevState };
    newState.array = newUsers;
    return newState;
  });
};

const onSearchPaginationError = (error) => {
  toastr.error("Failed to load search results.", error);
};

const triggerParentUpdate = (updatedUser) => {
  console.log("onUpdate", { updatedUser: updatedUser });

  setSubscribedUsers((prevState) => {
    const indexOfUser = prevState.array.findIndex((user) => user.email === updatedUser.email);

    if (indexOfUser >= 0) {
      prevState.array[indexOfUser] = updatedUser;
    }

    return {
      ...prevState,
      array: [...prevState.array],
    };
  });
};

const loadSubscribedUsers = () => {
  if (showSubscribedOnly) {
    listSubscribed(pageData.pageIndex, pageData.pageSize).then(onListSubscribedSuccess).catch(onListSubscribedError);
  } else if (searchQuery) {
    searchPagination(pageData.pageIndex, pageData.pageSize, searchQuery).then(onSearchPaginationSuccess).catch(onSearchPaginationError);
  } else {
    listAll(pageData.pageIndex, pageData.pageSize, false).then(onListAllSuccess).catch(onListAllError);
  }
};

const handleSearchQueryChange = (query) => {
  setSearchQuery(query);
};

return (
  <div className="newsletter-subscription-table">
    <table className="table table-striped">
      <tbody>
        <NewsletterSubscriptionsTableTheme triggerParentUpdate={triggerParentUpdate} subscribedUsers={subscribedUsers.array} onSearchQueryChange={handleSearchQueryChange} />
      </tbody>
    </table>
  </div>
);
};

export default NewsletterSubscriptionTable;
