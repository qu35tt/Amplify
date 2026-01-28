import { createBrowserRouter } from "react-router"

import { LoginPage } from "@/components/layout/login-page"
import { HomePage } from "@/components/layout/home-page"

export const router = createBrowserRouter([
    {
        path: "/",
        element: <LoginPage />
    },
    {
        path: "/home",
        element: <HomePage />
    }
    
])