import { useState } from "react"
import { Button } from "@/components/ui/button"
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import AmplifyLogo from "@/assets/amplifyLogo.png";
import * as z from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import axios from "axios";
import { toast } from "sonner";
import { useNavigate } from "react-router"
import { useAuthStore } from "@/stores/auth-store";

export function LoginPage(){
    const loginSchema = z.object({
        email: z.string().email({ message: "Invalid email address" }),
        password: z.string().min(6, { message: "Password must be at least 6 characters" }).max(16, { message: "Password must be at most 16 characters" })
    })

    type LoginFormValues = z.infer<typeof loginSchema>

    const [isLoading, setIsLoading] = useState(false);

    const { register, handleSubmit, formState: { errors } } = useForm<LoginFormValues>({
        resolver: zodResolver(loginSchema)
    });

    const nav = useNavigate();

    const authState = useAuthStore();

    const onSubmit = async (data: LoginFormValues) => {
        setIsLoading(true);
        try {
            const response = await axios.post(import.meta.env.VITE_API_URL+"auth/login", data);
            toast.success("Logged in succesfully!")
            authState.setToken(response.data.accessToken);
            nav("/home")

        } catch (error) {
            toast.error("Something went wrong!")
        } finally {
            setIsLoading(false);
        }
    };

    return(
        <div className="min-h-screen bg-amplify-dark flex items-center justify-center relative overflow-hidden">
            <div className="absolute top-1/2 left-1/2 -translate-x-1/2 -translate-y-1/2 w-196 h-196 bg-radial from-amplify-primary to-amplify-secondary rounded-full blur-[8rem] opacity-40 z-10" />

            <Card className="w-lg bg-amplify-surface/25 border-amplify-border text-white z-50 pb-12">
                <CardHeader>
                    <CardTitle className="flex justify-center"><img src={AmplifyLogo} className="w-3/5 h-3/5"/></CardTitle>
                    <CardDescription className="text-center text-white font-extrabold text-3xl">
                        Turn up the volume!
                    </CardDescription>
                </CardHeader>
                <CardContent>
                    <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-8">
                        <div className="flex flex-col gap-6">
                            <div className="grid gap-2">
                            <Label htmlFor="email">Email</Label>
                            <Input
                                id="email"
                                type="email"
                                placeholder="m@example.com"
                                className="h-12"
                                {...register("email")}
                            />
                            {errors.email && <span className="text-red-400 text-sm">{errors.email.message}</span>}
                            </div>
                            <div className="grid gap-2">
                            <div className="flex items-center">
                                <Label htmlFor="password">Password</Label>
                                <a
                                href="#"
                                className="ml-auto inline-block text-sm underline-offset-4 hover:underline"
                                >
                                Forgot your password?
                                </a>
                            </div>
                            <Input 
                                id="password" 
                                type="password"
                                placeholder="Enter your password..."
                                className="h-12" 
                                {...register("password")} 
                            />
                            {errors.password && <span className="text-red-400 text-sm">{errors.password.message}</span>}
                            </div>
                        </div>
                        <Button type="submit" disabled={isLoading} className="w-full h-16 cursor-pointer rounded-full bg-linear-to-r from-amplify-primary to-amplify-secondary font-bold text-2xl hover:scale-104 transition-transform">
                            {isLoading ? "Logging in..." : "Login"}
                        </Button>
                    </form>
                </CardContent>
                <CardFooter className="flex-col gap-8" />
            </Card>
        </div>
    )
}