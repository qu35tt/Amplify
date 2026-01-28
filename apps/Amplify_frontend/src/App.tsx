import { RouterProvider } from "react-router/dom";
import { router } from "@/services/router"

export function App() {
  return (
    <>
      <RouterProvider router={router} />
    </>
  )
}