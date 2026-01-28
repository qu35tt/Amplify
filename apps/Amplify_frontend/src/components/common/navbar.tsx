import { useState } from "react";
import AmplifyLogo from "@/assets/amplifyLogo.png";
import { Button } from "../ui/button";
import { Home, Library, Search } from "lucide-react";
import { Separator } from "../ui/separator";

export function Navbar() {
    const [selectedIndex, setSelectedIndex] = useState(0);

    const navItems = [
        { icon: Home, label: "Home" },
        { icon: Search, label: "Search" },
        { icon: Library, label: "Your Library" },
    ];

    return (
        <div className="absolute left-0 min-h-screen w-96 bg-black p-4 space-y-4">
            <div className="w-full flex justify-center">
                <img 
                    src={AmplifyLogo}
                    className="w-3/4 h-36"
                />
            </div>
            {navItems.map((item, index) => (
                <Button
                    key={index}
                    onClick={() => setSelectedIndex(index)}
                    className={`w-full justify-start gap-4 rounded-md p-8 text-white text-2xl hover:bg-gray-700/40 hover:border-amplify-border ${selectedIndex === index ? "bg-gray-700/40" : "bg-black"}`}
                >
                    <div className="relative size-8">
                        <div className={`absolute inset-0 bg-linear-to-r from-amplify-primary to-amplify-secondary blur-md rounded-full transition-opacity duration-300 ${selectedIndex === index ? "opacity-100" : "opacity-0"}`} />
                        <item.icon className="size-8 relative z-10" />
                    </div>
                    {item.label}
                </Button>
            ))}
            <Separator className="w-3/4 opacity-30" />
            {
                /* Additional navbar content can go here */
            }
        </div>
    )
}