import bpy

bl_info = {
    "name": "Peters Sculpt Objects",
    "description": "Creates basic shapes to start sculpting with",
    "author": "Peter",
    "version": (1, 0),
    "blender": (4, 10, 0),
    "location": "View3D > N-panel > Sculpt Object",
    "warning": "",
    "doc_url": "http://...",
    "support": "COMMUNITY",
    "category": "User Interface",
    }
    
    
class AddCubeOperator(bpy.types.Operator):
    bl_idname = "peterssculptaddon.addcubeoperator"
    bl_label = "Add a sculpt object"
        
    def execute(self, context):
        print("Start Sculpting!")
            
        #create a cube
        bpy.ops.mesh.primitive_cube_add(location=(0.0, 0.0, 0.0))
        obj = context.object
        scene = context.scene
        subdiv_levels = scene.int_property_001
            
        #add a subsurface modifier
        
        with bpy.context.temp_override(object=obj):
                
            #IF Bool = true, set subsurface modifier level to Int property
            if scene.bool_property_001 == True:
                bpy.ops.object.modifier_add(type="SUBSURF")
                bpy.context.object.modifiers["Subdivision"].levels = subdiv_levels
            else:
                pass
                
            #IF bool is True, Mirror modifier
            if scene.bool_property_002 == True:
                bpy.ops.object.modifier_add(type="MIRROR")
                bpy.context.object.modifiers["Mirror"].use_axis[0] = False
                bpy.context.object.modifiers["Mirror"].use_axis[1] = True
                bpy.context.object.modifiers["Mirror"].mirror_object = bpy.data.objects["Cube"]
            else:
                pass
                
                #Make the material of the object Red
                #If there is no material, create one
                
            material_sculpt = bpy.data.materials.get("Material")
                
            if material_sculpt is None:
                material_sculpt = bpy.data.materials.new(name="RedSculptMaterial")
                material_sculpt.diffuse_color=(0.415, 0.078, 0.015, 1)
                material_sculpt.roughness = 0.8
                    
            #make the cube's material the new material
            if obj.data.materials:
                obj.data.materials[0] = material_sculpt
            else:
                obj.data.materials.append(material_sculpt)
        return{"FINISHED"}
        
class PetersSculptAddon(bpy.types.Panel):
    bl_region_type = "UI"
    bl_space_type = "VIEW_3D"
    bl_category = "Sculpt Object"
    bl_label = "Sculpt Object"
    
    def draw(self, context):
        layout = self.layout
        scene = context.scene
        
        layout.label(text="Create Subdivision Cube")
        
        layout.prop(scene, "bool_property_001", text="Subdivide")
        
        if scene.bool_property_001 == True:
            layout.prop(scene, "int_property_001", text="Levels")
        else:
            pass
        
        layout.prop(scene, "bool_property_002", text="Mirror")
        
        layout.operator("peterssculptaddon.addcubeoperator", icon = "MESH_CUBE", text="Make it!")
        
classes = [
    PetersSculptAddon,
    AddCubeOperator
]
    
def register():
    for cls in classes:
        bpy.utils.register_class(cls)
        
    bpy.types.Scene.bool_property_001 = bpy.props.BoolProperty(name="Subdivide")
    bpy.types.Scene.int_property_001 = bpy.props.IntProperty(name="Subdivide level", min=0, max=5)
    bpy.types.Scene.bool_property_002 = bpy.props.BoolProperty(name="Mirror")
    
def unregister():
    for cls in reversed(classes):
        bpy.utils.register_class(cls)
        
    del bpy.types.Scene.bool_property_001
    del bpy.types.Scene.int_property_001
    del bpy.types.Scene.bool_property_002
    
    
if __name__ == "__main__":
    register()
        