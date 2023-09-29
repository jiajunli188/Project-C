import {  useUser } from "@clerk/clerk-react";

function capitalizeFirstLetter(str: any) {
  return str.charAt(0).toUpperCase() + str.slice(1);
}

export default function Home() {
  const { isSignedIn, user, isLoaded } = useUser();

  if (!isLoaded) {
    return null;
  }

  if (isSignedIn) {
    return (
      <div className="text-black">{capitalizeFirstLetter(user.username)}</div>
    );
  }

  return null;
}
